import { ComponentFixture, TestBed } from '@angular/core/testing';

//import { UserinfoComponent } from './userinfo.component';
import { UserinfoTestComponent } from './userinfo.component';

describe('UserinfoComponent', () => {
  let component: UserinfoTestComponent;
  let fixture: ComponentFixture<UserinfoTestComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UserinfoTestComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UserinfoTestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
