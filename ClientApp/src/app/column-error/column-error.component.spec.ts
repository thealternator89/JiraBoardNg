import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ColumnErrorComponent } from './column-error.component';

describe('ColumnErrorComponent', () => {
  let component: ColumnErrorComponent;
  let fixture: ComponentFixture<ColumnErrorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ColumnErrorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ColumnErrorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
