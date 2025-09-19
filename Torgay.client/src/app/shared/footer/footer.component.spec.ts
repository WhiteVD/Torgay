import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FooterComponent } from './footer.component';

describe('Footer', () => {
  let fixture: ComponentFixture<FooterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FooterComponent]
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FooterComponent);
    fixture.detectChanges();
  });

  it('should have a link to author', () => {
    const link = (fixture.nativeElement as HTMLElement).querySelector('.app-footer-link a');
    const href = link?.getAttribute('href');
    const text = link?.textContent;
    expect(href).toContain('https://www.ebenmonney.com');
    expect(text).toContain('www.ebenmonney.com');
  });
});
