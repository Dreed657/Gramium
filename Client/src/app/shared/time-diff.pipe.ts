import { formatDate } from '@angular/common';
import { Inject, LOCALE_ID, Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'timeDiffToString'
})
export class TimeDiffPipe implements PipeTransform {

  constructor(@Inject(LOCALE_ID) private locale: string) {}

  transform(value: Date): string {
    // const locale = 'en';

    const msPerMinute = 60 * 1000;
    const msPerHour = msPerMinute * 60;
    const msPerDay = msPerHour * 24;
    const msPerMonth = msPerDay * 30;
    const msPerYear = msPerMonth * 365;

    const valueDate = new Date(value);
    const offset = valueDate.getTimezoneOffset() / 60;
    const hours = valueDate.getHours();

    valueDate.setHours(hours - offset);

    const current = new Date();
    const elapsed = +current - +valueDate;

    if (elapsed < msPerMinute) {
      return formatDate(elapsed, 'ss', this.locale) + ' seconds ago';
    }
    if (elapsed < msPerHour) {
      return formatDate(elapsed, 'mm', this.locale) + ' minutes ago';
    }
    if (elapsed < msPerDay) {
      return formatDate(elapsed, 'H', this.locale) + ' hours ago';
    }
    if (elapsed < msPerMonth) {
      return formatDate(elapsed, 'd', this.locale) + ' days ago';
    }
    if (elapsed < msPerYear) {
      return formatDate(elapsed, 'M', this.locale) + ' months ago';
    }
    return formatDate(elapsed, 'y', this.locale) + ' years ago';
  }

}
