import { FormAgeComponent } from './pages/form-age/form-age.component';
import { UserFormComponent } from './pages/form-connexion/form-connexion.component';
import { UserinfoTestComponent } from './pages/userinfo/userinfo.component';
//import { HomePage } from './pages/home/home.page';
import { Routes } from '@angular/router';

export const routes: Routes = [
  { path: 'test-userinfo', component: UserinfoTestComponent },
  { path: 'form-connexion', component: UserFormComponent },
  { path: 'form-age', component: FormAgeComponent }
];
