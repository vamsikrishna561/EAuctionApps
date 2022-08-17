import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'shorten'
})
export class ShortenPipe implements PipeTransform {

  transform(value: any, maxLength: number): any {
    if(value && value.length > maxLength){
      return value.substr(0, maxLength) + '...';
    }

    return value;
  }

}
