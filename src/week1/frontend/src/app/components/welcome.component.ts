import { Component, VERSION } from '@angular/core';

@Component({
  selector: 'app-welcome',
  imports: [],
  template: `
    <div class="prose pt-12">
      <h1>Angular Starter</h1>
      <p>Using Angular {{ v.full }}</p>

      <ul>
        <li><a href="https://tailwindcss.com/">Tailwind for CSS</a></li>
        <li><a href="https://daisyui.com/">DaisyUi for UI Library</a></li>
        <li><a href="https://mswjs.io/">Mock Service Workers</a></li>
        <li><a href="https://prettier.io/">Prettier</a></li>
        <li><a href="https://eslint.org/">ESLint</a></li>
      </ul>
    </div>
  `,
  styles: ``,
})
export class WelcomeComponent {
  v = VERSION;
}
