import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EcomMasterComponent } from './ecommaster.component';

describe('EcomMasterComponent', () => {
  let component: EcomMasterComponent;
  let fixture: ComponentFixture<EcomMasterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EcomMasterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EcomMasterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
