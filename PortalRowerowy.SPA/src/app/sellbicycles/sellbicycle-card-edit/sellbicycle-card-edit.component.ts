import { Component, OnInit, Input } from '@angular/core';
import { SellBicycle } from 'src/app/_models/sellBicycle';
import { AuthService } from 'src/app/_services/auth.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { SellBicycleService } from 'src/app/_services/sellBicycle.service';

@Component({
  selector: 'app-sellbicycle-card-edit',
  templateUrl: './sellbicycle-card-edit.component.html',
  styleUrls: ['./sellbicycle-card-edit.component.css']
})
export class SellBicycleCardEditComponent implements OnInit {

  @Input() sellBicycle: SellBicycle;
  sellBicycles: SellBicycle [];

  constructor(private authService: AuthService,
    private sellBicycleService: SellBicycleService,
    private alertify: AlertifyService) { }

  ngOnInit() {
  }

  // sendLike(id: number) {
  //   this.userService.sendLike(this.authService.decodedToken.nameid, id)
  //     .subscribe(data => {
  //       this.alertify.success('Polubiłeś: ' + this.sellBicycle.sellBicycleName[0].toUpperCase()
  //         + this.sellBicycle.sellBicycleName.slice(1) + '!');
  //     }, error => {
  //       this.alertify.error(error);
  //     });
  // }

  deleteSellBicycle(id: number) {
    this.alertify.confirm('Czy jesteś pewien, czy chcesz usunąć ogłoszenie?', () => {
      this.sellBicycleService.deleteSellBicycle(/*this.authService.decodedToken.nameid*/this.sellBicycle.id).subscribe(() => {
        this.sellBicycles.splice(this.sellBicycles.findIndex(p => p.id === id), 1);
        this.alertify.success('Ogłoszenie zostało usunięte!');
      }, error => {
        this.alertify.error('Nie udało się usunąć ogłoszenia!');
      });
    });
}}