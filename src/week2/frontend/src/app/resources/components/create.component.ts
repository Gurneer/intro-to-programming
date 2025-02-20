import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { ResourceStore } from '../services/resource.store';
import { ResourceListItemCreateModel } from '../types';

@Component({
  selector: 'app-resources-create',
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [ReactiveFormsModule], // this is going to be replaced "sometime soon" with a signals based forms module.
  template: `
    <p>Create a New Resource</p>

    <form [formGroup]="form" class="w-1/3" (ngSubmit)="addItem()">
      <div class="form-control">
        <label for="title" class="label"
          >Title:

          <input
            type="text"
            id="title"
            class="input input-bordered"
            formControlName="title"
          />
        </label>
      </div>
      @let titlef = form.controls.title;
      @if (titlef.invalid && (titlef.dirty || titlef.touched)) {
        <div class="alert alert-error">
          @if (titlef.hasError('required')) {
            <p>We need a title to display for this resource.</p>
          }
          @if (titlef.hasError('minlength')) {
            @let mlError = titlef.getError('minlength');
            <p>This must be at least {{ mlError['requiredLength'] }} letters</p>
          }
          @if (titlef.hasError('maxlength')) {
            <p>This can't be more than 100 characters</p>
          }
        </div>
      }
      <div class="form-control">
        <label for="description" class="label"
          >Description:

          <textarea
            id="description"
            class="input input-bordered"
            formControlName="description"
          ></textarea>
        </label>
      </div>
      <div class="form-control">
        <label for="link" class="label"
          >Link:

          <input
            type="url"
            id="link"
            class="input input-bordered"
            formControlName="link"
          />
        </label>
      </div>
      @let linkf = form.controls.link;
      @if (linkf.invalid && (linkf.dirty || linkf.touched)) {
        <div class="alert alert-error">
          @if (linkf.hasError('required')) {
            <p>A link is required</p>
          }
        </div>
      }
      <div class="form-control">
        <label for="linkText" class="label"
          >Link Text:

          <input
            type="text"
            id="linkText"
            class="input input-bordered"
            formControlName="linkText"
          />
        </label>
        @let ltf = form.controls.linkText;
        @if (ltf.invalid && (ltf.dirty || ltf.touched)) {
          <div class="alert alert-error">
            @if (ltf.hasError('required')) {
              <p>You have to give us some text to show with the link</p>
            }
            @if (ltf.hasError('minlength')) {
              @let mlError = ltf.getError('minlength');
              <p>
                This must be at least {{ mlError['requiredLength'] }} letters
              </p>
            }
            @if (ltf.hasError('maxlength')) {
              <p>This can't be more than 20 characters</p>
            }
          </div>
        }
      </div>
      <div class="form-control">
        <label for="tags" class="label"
          >Tags:

          <input
            type="text"
            id="tags"
            class="input input-bordered"
            formControlName="tags"
          />
        </label>
      </div>
      <button type="submit" class="btn btn-primary">Add This Item</button>
    </form>
  `,
  styles: ``,
})
export class CreateComponent {
  store = inject(ResourceStore);

  form = new FormGroup({
    title: new FormControl<string>('', {
      nonNullable: true,
      validators: [
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(100),
      ],
    }),
    description: new FormControl<string>('', { nonNullable: true }),
    link: new FormControl<string>('', {
      nonNullable: true,
      validators: [Validators.required],
    }),
    linkText: new FormControl<string>('', {
      nonNullable: true,
      validators: [
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(20),
      ],
    }),
    tags: new FormControl<string>('', { nonNullable: true }),
  });

  addItem() {
    if (this.form.valid) {
      const itemToSend = this.form
        .value as unknown as ResourceListItemCreateModel;
      this.store.add(itemToSend);

      this.form.reset();
    } else {
      this.form.markAllAsTouched();
      console.log('Form is invalid');
    }
  }
}
