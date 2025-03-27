import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { UserInfo } from '../models/userinfo.model';
import { UserinfoMapper } from '../mapper/userinfo.mapper';

@Injectable({ providedIn: 'root' })
export class UserinfoService {
  getCurrent() {
    throw new Error('Method not implemented.');
  }
  private readonly baseUrl = 'https://localhost:5000/auth/userinfo';

  constructor(
    private readonly client: HttpClient,
    private readonly userinfoMapper: UserinfoMapper
  ) {}

  public list(): Observable<UserInfo[]> {
    return this.client.get<any[]>(this.baseUrl).pipe(
      map(data => data.map(dto => this.userinfoMapper.fromDto(dto)))
    );
  }
  public getById(id: string): Observable<UserInfo> {
    return this.client.get<any>(`${this.baseUrl}/${id}`).pipe(
      map(data => this.userinfoMapper.fromDto(data))
    );
  }

}
