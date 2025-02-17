import { signal } from '@angular/core';

export class BankService {
  private _currentBalance = signal(5000);

  public getCurrentBalance() {
    return this._currentBalance.asReadonly(); // don't want anyone but me changing this.
  }

  public deposit(amount: number) {
    // business logic goes here.
    this._currentBalance.update((c) => c + amount);
  }

  public withdraw(amount: number) {
    this._currentBalance.update((c) => c - amount);
  }
}
