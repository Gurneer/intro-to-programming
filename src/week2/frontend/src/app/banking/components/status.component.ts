import {
  Component,
  ChangeDetectionStrategy,
  input,
  output,
  signal,
} from '@angular/core';

@Component({
  selector: 'app-banking-status',
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [],
  template: ` <div class="alert alert-info">
    <p class="text-2xl font-bold">ALERT</p>
    <p>{{ message() }}</p>
    <button
      [disabled]="buttonDisabled()"
      (click)="onAlertClosed()"
      class="btn btn-xs btn-warning"
    >
      X
    </button>
  </div>`,
  styles: ``,
})
export class StatusComponent {
  message = input.required<string>();

  alertClosed = output();
  buttonDisabled = signal(false);
  onAlertClosed() {
    this.alertClosed.emit();
  }
}
