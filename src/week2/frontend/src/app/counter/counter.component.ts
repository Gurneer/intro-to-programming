import {
  Component,
  ChangeDetectionStrategy,
  signal,
  computed,
} from '@angular/core';

@Component({
  selector: 'app-counter',
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [],
  template: `
    <div>
      <button (click)="decrement()" class="btn btn-primary">-</button>
      <span>{{ current() }}</span>
      <button (click)="increment()" class="btn btn-primary">+</button>

      @if (isEven()) {
        <p>That Number Is Even</p>
      } @else {
        <p>That Number Is Odd</p>
      }
    </div>
  `,
  styles: ``,
})
export class CounterComponent {
  current = signal(1);
  isEven = computed(() => this.current() % 2 === 0);
  constructor() {
    setInterval(() => {
      console.log('Time to update the count');
      this.current.update((c) => c + 1);
    }, 1000);
  }
  increment() {
    this.current.update((c) => c + 1);
  }
  decrement() {
    this.current.update((c) => c - 1);
  }

  loadTheData() {}
}
