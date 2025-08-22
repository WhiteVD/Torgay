// ======================================
// Author: Ebenezer Monney
// Copyright (c) 2023 www.ebenmonney.com
// 
// ==> Gun4Hire: contact@ebenmonney.com
// ======================================

import { TestBed } from '@angular/core/testing';
import { provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';

import { AdminComponent } from './admin.component';

describe('AdminComponent', () => {
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AdminComponent],
      providers: [provideHttpClient(withInterceptorsFromDi())]
    }).compileComponents();
  });

  it('Placeholder - AdminComponent', () => {
    //expect(true).toBe(true);
  });
});
