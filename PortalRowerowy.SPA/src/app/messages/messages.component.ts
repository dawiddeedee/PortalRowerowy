import { Component, OnInit } from '@angular/core';
import { Pagination, PaginationResult } from '../_models/pagination';
import { AuthService } from '../_services/auth.service';
import { UserService } from '../_services/user.service';
import { ActivatedRoute } from '@angular/router';
import { AlertifyService } from '../_services/alertify.service';
import { Message } from '../_models/message';
import { MessagesResolver } from '../_resolvers/messages.resolver';
import { User } from '../_models/user';

@Component({
  selector: 'app-messages',
  templateUrl: './messages.component.html',
  styleUrls: ['./messages.component.css']
})
export class MessagesComponent implements OnInit {

  messages: Message[];
  pagination: Pagination;
  messageContainer = 'Nieprzeczytane';
  userParams: any = {};
  users: User[];

  constructor(private userService: UserService,
    private authService: AuthService,
    private route: ActivatedRoute,
    private alertify: AlertifyService) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.messages = data.messages.result;
      this.pagination = data.messages.pagination;
    });
  }

  loadMessages() {
    this.userService.getMessages(this.authService.decodedToken.nameid, this.pagination.currentPage,
                                  this.pagination.itemsPerPage, this.messageContainer)
        .subscribe((res: PaginationResult<Message[]>) => {
          this.messages = res.result;
          this.pagination = res.pagination;

          // if (res.result[0].messageContainer === 'Outbox') {
          //   this.flagaOutbox = true;
          // } else {
          //   this.flagaOutbox = false;
          // }

        }, error => {
          this.alertify.error(error);
        });
  }

  pageChanged(event: any): void {
    this.pagination.currentPage = event.page;
    this.loadMessages();
  }

}
