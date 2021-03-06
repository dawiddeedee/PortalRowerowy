import { Component, OnInit } from '@angular/core';
import { Adventure } from 'src/app/_models/adventure';
import { AdventureService } from 'src/app/_services/adventure.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { ActivatedRoute } from '@angular/router';
import { NgxGalleryOptions, NgxGalleryImage, NgxGalleryAnimation } from 'ngx-gallery';
import { User } from 'src/app/_models/user';
import { AuthService } from 'src/app/_services/auth.service';
import { UserService } from 'src/app/_services/user.service';

@Component({
  selector: 'app-adventure-detail',
  templateUrl: './adventure-detail.component.html',
  styleUrls: ['./adventure-detail.component.css']
})
export class AdventureDetailComponent implements OnInit {

  adventure: Adventure;
  galleryOptions: NgxGalleryOptions[];
  galleryImages: NgxGalleryImage[];
  
 

  constructor(private adventureService: AdventureService,
    private alertify: AlertifyService, private authService: AuthService,
    private route: ActivatedRoute,  private userService: UserService) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.adventure = data.adventure;
    });

    this.galleryOptions = [
      {
        width: '500px',
        height: '500px',
        thumbnailsColumns: 4,
        imagePercent: 100,
        preview: false,
        imageAnimation: NgxGalleryAnimation.Slide
      }
    ];

    this.galleryImages = this.getImages();
  }


  // loadAdventure() {
  //   this.adventureService.getAdventure(+this.route.snapshot.params.id)
  //     .subscribe((adventure: Adventure) => {
  //       this.adventure = adventure;
  //     }, error => {
  //       this.alertify.error(error);
  //     });
  // }

  getImages() {
    const imagesUrls = [];
    // tslint:disable-next-line: prefer-for-of
    for (let i = 0; i < this.adventure.adventurePhotos.length; i++) {
      imagesUrls.push({
        small: this.adventure.adventurePhotos[i].url,
        medium: this.adventure.adventurePhotos[i].url,
        big: this.adventure.adventurePhotos[i].url,
        descriptio: this.adventure.adventurePhotos[i].description,
      });
    }
    return imagesUrls;
  }

  sendLike(id: number) {
    this.userService.sendAdventureLike(this.authService.decodedToken.nameid, id)
      .subscribe(data => {
        this.alertify.success('Polubiłeś: ' + this.adventure.adventureName + '!');
      }, error => {
        this.alertify.error('Już nie lubisz tej wyprawy!');
      });
  }

}

// import { Component, OnInit, ViewChild } from '@angular/core';
// import { Adventure } from 'src/app/_models/adventure';
// import { AdventureService } from 'src/app/_services/adventure.service';
// import { AlertifyService } from 'src/app/_services/alertify.service';
// import { ActivatedRoute } from '@angular/router';
// import { NgxGalleryOptions, NgxGalleryImage, NgxGalleryAnimation } from 'ngx-gallery';
// import { TimeAgoPipe } from '../../_pipes/time-ago-pipe';
// import { TabsetComponent } from 'ngx-bootstrap';
// import { AuthService } from 'src/app/_services/auth.service';

// @Component({
//   selector: 'app-adventure-detail',
//   templateUrl: './adventure-detail.component.html',
//   styleUrls: ['./adventure-detail.component.css']
// })
// export class AdventureDetailComponent implements OnInit {

//   @ViewChild('adventureTabs', { static: true }) adventureTabs: TabsetComponent;
//   adventure: Adventure;
//   // adventure: Adventure;
//   // adventures: Adventure[];
//   // galleryOptions: NgxGalleryOptions[];
//   // galleryImages: NgxGalleryImage[];
//   // galleryAdventures: NgxGalleryImage[];

//   constructor(private adventureService: AdventureService,
//     // tslint:disable-next-line: align
//     private alertify: AlertifyService,
//     // tslint:disable-next-line: align
//     private route: ActivatedRoute,
//     private authService: AuthService) { }

//   ngOnInit() {
//     // tslint:disable-next-line: comment-format
//     //this.loadUser();
//     this.route.data.subscribe(data => {
//       this.adventure = data.adventure;
//       // this.adventure = data.adventure;
//     });

//     this.route.queryParams.subscribe(params => {
//       const selectTab = params.tab;
//       this.adventureTabs.tabs[selectTab > 0 ? selectTab : 0].active = true;
//     });

//     this.galleryOptions = [
//       {
//         width: '500px',
//         height: '500px',
//         thumbnailsColumns: 4,
//         imagePercent: 100,
//         preview: false,
//         imageAnimation: NgxGalleryAnimation.Slide,
//         /*    },
//             // max-width 800
//             {
//                 breakpoint: 800,
//                 width: '100%',
//                 height: '600px',
//                 imagePercent: 80,
//                 thumbnailsPercent: 20,
//                 thumbnailsMargin: 20,
//                 thumbnailMargin: 20
//             },
//             // max-width 400
//             {*/
//         // breakpoint: 400,
//       }
//     ];

//     //this.galleryImages = this.getImages();
//     // this.galleryAdventures = this.getAdventures();
//     /* {
//          small: 'assets/1-small.jpg',
//          medium: 'assets/1-medium.jpg',
//          big: 'assets/1-big.jpg'
//      },
//      {
//          small: 'assets/2-small.jpg',
//          medium: 'assets/2-medium.jpg',
//          big: 'assets/2-big.jpg'
//      },
//      {
//          small: 'assets/3-small.jpg',
//          medium: 'assets/3-medium.jpg',
//          big: 'assets/3-big.jpg'
//      }*/
//   }

//   getImages() {
//     const imagesUrls = [];
//     // tslint:disable-next-line: prefer-for-of
//     for (let i = 0; i < this.adventure.adventurePhotos.length; i++) {
//       imagesUrls.push({
//         small: this.adventure.adventurePhotos[i].url,
//         medium: this.adventure.adventurePhotos[i].url,
//         big: this.adventure.adventurePhotos[i].url,
//         descriptio: this.adventure.adventurePhotos[i].description,
//       });
//     }
//     return imagesUrls;
//     // loadUser() {
//     //   this.userService.getUser(+this.route.snapshot.params.id).
//     //   subscribe((user: User) => {
//     //     this.user = user;
//     //   }, error => {
//     //     this.alertify.error(error);
//     //   });
//     // }

//   }




//   // getAdventures() {
//   //   const adventuresUrls = [];
//   //   // tslint:disable-next-line: prefer-for-of
//   //   for (let i = 0; i < this.adventure.adventures.length; i++) {
//   //     adventuresUrls.push({
//   //       small: this.adventure.adventures[i].url,
//   //       medium: this.adventure.adventures[i].url,
//   //       big: this.adventure.adventures[i].url,
//   //       descriptio: this.adventure.adventures[i].description,
//   //     });
//   //   }
//   //   return adventuresUrls;
//   //   // loadUser() {
//   //   //   this.userService.getUser(+this.route.snapshot.params.id).
//   //   //   subscribe((user: User) => {
//   //   //     this.user = user;
//   //   //   }, error => {
//   //   //     this.alertify.error(error);
//   //   //   });
//   //   // }

//   // }

//   // selectTab(tabId: number) {
//   //   this.adventureTabs.tabs[tabId].active = true;
//   // }

//   // sendLike(id: number) {
//   //   this.adventureService.sendLike(this.authService.decodedToken.nameid, id)
//   //     .subscribe(data => {
//   //       this.alertify.success('Polubiłeś: ' + this.adventure.adventurename);
//   //     }, error => {
//   //       this.alertify.error('Już lubisz tego użytkownika');
//   //     });
//   // }
// }
