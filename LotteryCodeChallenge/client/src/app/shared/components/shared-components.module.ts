import { HttpService } from './../services/http.service';
import { SharedServicesModule } from './../services/shared-services.module';
import { MaterialComponentsModule } from './../material/material-components.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule  } from '@angular/platform-browser/animations';
import { TableComponent } from './table/table.component';
import { TopbarComponent } from './topbar/topbar.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [TopbarComponent, TableComponent],
  imports: [
    CommonModule,
    MaterialComponentsModule,
    BrowserAnimationsModule,
    SharedServicesModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  exports: [
    TopbarComponent,
    TableComponent
  ],
  providers: [HttpService]
})
export class SharedComponentsModule { }
