import { Component } from '@angular/core';

import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';//import pour pouvoir generer un formulaire
import { CommonModule } from '@angular/common';
@Component({
  selector: 'app-form-age',
  standalone: true,
  imports: [CommonModule,ReactiveFormsModule],
  templateUrl: './form-age.component.html',
  styleUrl: './form-age.component.scss'
})
export class FormAgeComponent {
  public group = new FormGroup({
    name: new FormControl<string | null>(null,{
      validators:Validators.required,
    }),
    pwd: new FormControl<string | null>(null,{
      validators:Validators.required,
    })
  });
  //constructor(private readonly builder:FormAgeComponent){}

  protected handleSubmit(event: SubmitEvent) {
    this.group.controls.name.markAllAsTouched();
    this.group.controls.name.markAsDirty();
    this.group.controls.name.updateValueAndValidity();
    if(this.group.valid){
      console.log("hello !")
    }
  }
}
