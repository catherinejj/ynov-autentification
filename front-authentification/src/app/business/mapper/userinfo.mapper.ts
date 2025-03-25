import { Injectable } from '@angular/core';
import { UserInfo } from '../models/userinfo.model';
import { UserinfoService } from '../services/userinfo.service';

@Injectable({ providedIn: 'root' })
export class UserinfoMapper {
  public fromDto(dto: any): UserInfo {
    return {
      id: dto.id || 'unknown',
      name: dto.name || 'User inconnue',
      email:dto.email || 'User inconnue',
    };
  }

  public toDto(model: UserInfo): any {
    return {
      id: model.id,
      name: model.name,
      email: model.email
    };
  }
}
