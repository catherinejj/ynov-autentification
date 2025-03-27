import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormAgeComponent } from './form-age.component';

describe('FormAgeComponent', () => {
  let component: FormAgeComponent;
  let fixture: ComponentFixture<FormAgeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FormAgeComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FormAgeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
