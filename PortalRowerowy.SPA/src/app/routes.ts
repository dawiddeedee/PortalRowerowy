import { Routes } from '@angular/router'
import { HomeComponent } from './home/home.component'
import { UserListComponent } from './users/user-list/user-list.component'
import { FriendsComponent } from './friends/friends.component'
import { NewsComponent } from './news/news.component'
import { AdventuresComponent } from './adventures/adventures.component'
import { MessagesComponent } from './messages/messages.component'
import { SellbicyclesComponent } from './sellbicycles/sellbicycles.component'

export const appRoutes: Routes = {
    { path: 'home', component: HomeComponent },
    { path: 'użytkownicy', component: UserListComponent },
    { path: 'przyjaciele', component: FriendsComponent },
    { path: 'wydarzenia', component: NewsComponent },
    { path: 'wyprawy', component: AdventuresComponent },
    { path: 'wiadomości', component: MessagesComponent },
    { path: 'Giełda', component: SellbicyclesComponent },

}