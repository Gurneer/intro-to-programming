import { CurrencyPipe } from '@angular/common';
import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { BankStore } from './services/bank.store';

@Component({
  selector: 'app-banking',
  changeDetection: ChangeDetectionStrategy.OnPush,

  imports: [CurrencyPipe, RouterOutlet, RouterLink],
  template: `
    <div>
      <p>
        Your Checking Balance is {{ store.currentBalance() | currency }}
        <a routerLink="deposit" class="btn btn-xs btn-secondary"
          >Make a Deposit</a
        >
        @if (store.currentBalance() > 0) {
          <a routerLink="withdrawal" class="btn btn-xs btn-secondary"
            >Make a Withdrawal</a
          >
        }
      </p>
      <div>
        <router-outlet />
      </div>
    </div>
  `,
  styles: ``,
})
export class BankingComponent {
  store = inject(BankStore);
}
