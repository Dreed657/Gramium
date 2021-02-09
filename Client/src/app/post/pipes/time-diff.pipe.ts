import { Inject, LOCALE_ID, Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'timeDiff'
})
export class TimeDiffPipe implements PipeTransform {

  constructor(@Inject(LOCALE_ID) private locale: string) { }

  transform(value: Date): unknown {
    const locale = 'en';
    const rtf = new Intl.DateTimeFormat(locale);

    return rtf.format(value);
  }
}
