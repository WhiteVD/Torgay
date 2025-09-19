import { TestBed } from '@angular/core/testing';
import { provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';

import { UserListComponent } from './user-list.component';

describe('UserListComponent', () => {
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UserListComponent],
      providers: [provideHttpClient(withInterceptorsFromDi())]
    }).compileComponents();
  });

  it('Placeholder - UserListComponent', () => {
    //expect(true).toBe(true);
  });
});
