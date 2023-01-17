import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-user-list',
    templateUrl: './user-list.component.html',
    styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {
    users: any;

    constructor(private http: HttpClient) { }

    /* 
        The constructor is considered too early to be grabbing data from an API,
        so we implement OnInit, a lifecycle hook
     */
    ngOnInit(): void {
        this.http.get("https://localhost:5001/api/users").subscribe({
            next: response => this.users = response,
            error: error => console.log(error),
            complete: () => console.log("Request has completed")
        });
    }
}
