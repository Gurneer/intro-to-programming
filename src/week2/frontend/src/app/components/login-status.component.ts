import { Component, ChangeDetectionStrategy, signal } from '@angular/core';

@Component({
  selector: 'app-login-status',
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [],
  template: `
    @if (isLoggedIn()) {
      <button (click)="logOut()" class="btn btn-primary">
        Log Out {{ userName() }}
      </button>
    } @else {
      <button (click)="logIn()" class="btn btn-warning">Log In</button>
    }
  `,
  styles: ``,
})
export class LoginStatusComponent {
  isLoggedIn = signal(true);
  userName = signal('Bob@Aol.Com');

  logIn() {
    // do the login dance.. TODO
    this.isLoggedIn.set(true);
  }

  logOut() {
    this.isLoggedIn.set(false);
  }
}
