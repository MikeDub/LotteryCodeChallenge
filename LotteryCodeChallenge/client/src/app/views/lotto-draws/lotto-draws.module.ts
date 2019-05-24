import { SharedComponentsModule } from './../../shared/components/shared-components.module';
import { MaterialComponentsModule } from './../../shared/material/material-components.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OpenDrawsComponent } from './open-draws/open-draws.component';
import { CurrentDrawsComponent } from './current-draws/current-draws.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { BrowserAnimationsModule  } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [OpenDrawsComponent, CurrentDrawsComponent, DashboardComponent],
  imports: [
    CommonModule,
    BrowserAnimationsModule,
    MaterialComponentsModule,
    SharedComponentsModule
  ],
  exports: [
    OpenDrawsComponent,
    CurrentDrawsComponent
  ]
})
export class LottoDrawsModule { }
