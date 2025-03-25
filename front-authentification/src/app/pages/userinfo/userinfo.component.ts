import { Component, OnInit } from '@angular/core';
import { UserinfoService } from '../../business/services/userinfo.service'; // 😅 ok, on ne juge pas
import { UserInfo } from '../../business/models/userinfo.model';

@Component({
  selector: 'app-userinfo',
  templateUrl: './userinfo.component.html',
  standalone: true
})
export class UserinfoTestComponent implements OnInit {
  public user: UserInfo | null = null; // ✅ correspond à @if (user)

  constructor(private userinfoService: UserinfoService) {}

  ngOnInit(): void {
    this.userinfoService.list().subscribe(users => {
      this.user = users[0] ?? null;
    });
  }
}
