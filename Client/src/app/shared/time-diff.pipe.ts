import { formatDate } from '@angular/common';
import { Inject, LOCALE_ID, Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'timeDiffToString'
})
export class TimeDiffPipe implements PipeTransform {

  constructor(@Inject(LOCALE_ID) private locale: string) { }

  transform(value: Date): string {
    const span = new Date(+new Date().getUTCDate() - +new Date(value));

    if (span.getDay() > 365) {
      let years = span.getDay() / 365;

      if (span.getDay() % 365 !== 0) {
        years += 1;
      }

      return `${years} years ago`;
    }
    else if (span.getDay() > 30) {
      let months = span.getDay() / 30;

      if (span.getDay() % 31 !== 0) {
        months += 1;
      }
      return `${months} months ago`;
    }
    else if (span.getDay() > 0) {
      return `${span.getDay()} days ago`;
    }
    else if (span.getHours() > 0) {
      return `${span.getHours()} hours ago`;
    }
    else if (span.getMinutes() > 0) {
      return `${span.getMinutes()} minutes ago`;
    }
    else if (span.getSeconds() > 5) {
      return `${span.getSeconds()} seconds ago`;
    }
    else if (span.getSeconds() <= 5) {
      return `just now`;
    }

    return '';
  }

}
