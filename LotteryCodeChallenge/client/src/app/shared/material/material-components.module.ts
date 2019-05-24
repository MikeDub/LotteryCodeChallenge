
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
// Buttons and Forms
import { MatButtonModule, MatCardModule, MatChipsModule, MatDividerModule, MatInputModule,
  MatFormFieldModule } from '@angular/material';
// Nofitications
import { MatSnackBarModule } from '@angular/material';
// Tables
import { MatTableModule, MatPaginatorModule, MatSortModule } from '@angular/material';
// Navigation
import { MatToolbarModule, MatMenuModule, MatIconModule, MatSidenavModule, MatGridListModule } from '@angular/material';

@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ],
  exports: [
    // Buttons / Forms / Layout
    MatButtonModule,
    MatCardModule,
    MatChipsModule,
    MatDividerModule,
    MatInputModule,
    MatFormFieldModule,
    // Notifications
    MatSnackBarModule,
    // Tables
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    // Navigation
    MatToolbarModule,
    MatMenuModule,
    MatIconModule,
    MatSidenavModule,
    MatGridListModule
  ]
})
export class MaterialComponentsModule { }
