import { Component, ElementRef, OnInit, Renderer2 } from '@angular/core';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {

  constructor(private el: ElementRef, private renderer: Renderer2) {}

  ngOnInit(): void {
    const messageBox = this.el.nativeElement.querySelector('.js-message');
    const btn = this.el.nativeElement.querySelector('.js-message-btn');
    const card = this.el.nativeElement.querySelector('.js-profile-card');
    const closeBtn = this.el.nativeElement.querySelectorAll('.js-message-close');

    this.renderer.listen(btn, 'click', (e) => {
      e.preventDefault();
      this.renderer.addClass(card, 'active');
    });

    closeBtn.forEach(element => {
      this.renderer.listen(element, 'click', (e) => {
        e.preventDefault();
        this.renderer.removeClass(card, 'active');
      });
    });
  }
}
