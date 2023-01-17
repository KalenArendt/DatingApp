import { Component, OnInit } from '@angular/core';
import { User } from './_models/user';
import { AccountService } from './_services/account.service';

@Component({
   selector: 'app-root',
   templateUrl: './app.component.html',
   styleUrls: ['./app.component.css']
})


export class AppComponent implements OnInit {
   title = 'Mix n Match';

   constructor(private accountService: AccountService) { }

   /* 
       The constructor is considered too early to be grabbing data from an API,
       so we implement OnInit, a lifecycle hook
    */
   ngOnInit(): void {
      this.setCurrentUser();
   }
   
   setCurrentUser() {
      const userString = localStorage.getItem("user");
      if (!userString) return;
      
      const user: User = JSON.parse(userString);
      this.accountService.setCurrentUser(user);
   }
}
