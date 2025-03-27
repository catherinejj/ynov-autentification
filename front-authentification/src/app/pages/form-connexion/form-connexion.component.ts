import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';//import pour pouvoir generer un formulaire
import { User } from '../../business/models/user';

@Component({
  selector: 'app-form-connexion',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './form-connexion.component.html',
  styleUrl: './form-connexion.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class UserFormComponent {
  //protected name='';
  //protected pwd='';
  protected user = {
    name: '',
    pwd: ''
  };

  protected handleSubmit(envent: SubmitEvent){
    console.log("ooo");
  }
}
