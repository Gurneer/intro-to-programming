import { Directive, HostListener, ElementRef } from '@angular/core';

// An Angular directive that can be applied to an input that validates if it is a credit card number using the Luhn algorithm

@Directive({
  selector: '[appCreditCard]',
})
export class CreditCardDirective {
  constructor(private el: ElementRef) {}

  @HostListener('input', ['$event'])
  onInputChange(event: Event): void {
    const input = this.el.nativeElement.value;
    if (!this.luhnCheck(input)) {
      this.el.nativeElement.setCustomValidity('Invalid credit card number');
    } else {
      this.el.nativeElement.setCustomValidity('');
    }
  }

  private luhnCheck(value: string): boolean {
    let sum = 0;
    let shouldDouble = false;

    for (let i = value.length - 1; i >= 0; i--) {
      let digit = parseInt(value.charAt(i), 10);

      if (shouldDouble) {
        digit *= 2;
        if (digit > 9) {
          digit -= 9;
        }
      }

      sum += digit;
      shouldDouble = !shouldDouble;
    }

    return sum % 10 === 0;
  }
}
