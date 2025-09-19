import { TestBed } from '@angular/core/testing';
import { provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';

import { RoleListComponent } from './role-list.component';

describe('RoleListComponent', () => {
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RoleListComponent],
      providers: [provideHttpClient(withInterceptorsFromDi())]
    }).compileComponents();
  });

  it('Placeholder - RoleListComponent', () => {
    //expect(true).toBe(true);
  });
});
