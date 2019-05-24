import { SharedComponentsModule } from './shared/components/shared-components.module';
import { FaqModule } from './views/faq/faq.module';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashboardComponent } from './views/lotto-draws/dashboard/dashboard.component';
import { OpenDrawsComponent } from './views/lotto-draws/open-draws/open-draws.component';
import { CurrentDrawsComponent } from './views/lotto-draws/current-draws/current-draws.component';
import { FaqComponent } from './views/faq/faq.component';
import { LottoDrawsModule } from './views/lotto-draws/lotto-draws.module';

const appRoutes: Routes = [
  { path: 'draws/open', component: OpenDrawsComponent },
  { path: 'draws/current', component: CurrentDrawsComponent },
  {
    path: 'dashboard',
    component: DashboardComponent,
    data: { title: 'Lotto Draws Dashboard' }
  },
  {
    path: 'faq',
    component: FaqComponent,
    data: { title: 'Frequently Asked Questions' }
  },
  { path: '',
    redirectTo: '/dashboard',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [
    LottoDrawsModule,
    FaqModule,
    SharedComponentsModule,
    RouterModule.forRoot(appRoutes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

export const routing = RouterModule.forRoot(appRoutes);
