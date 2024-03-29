import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
//import {LoaderComponent} from './loader/loader.component';
//import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
//import {MinDirective} from './directives/min.directive';
import {ShortenPipe} from './pipes/shorten.pipe';
//import {ChangeThemeDirective} from './directives/change-theme.directive';
//import {LikeIconComponent} from './like-icon/like-icon.component';
//import {FontAwesomeModule} from '@fortawesome/angular-fontawesome';

@NgModule({
  declarations: [ShortenPipe],
  imports: [
    CommonModule
  ],
  exports: [ShortenPipe]
})
// @ts-ignore
export class SharedModule {
}
