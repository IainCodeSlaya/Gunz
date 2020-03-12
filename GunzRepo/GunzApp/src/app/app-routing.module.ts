import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { GunComponent } from './gun/gun.component';
import { GuntypeComponent } from './guntype/guntype.component';
import { GunautomaticComponent } from './gunautomatic/gunautomatic.component';
import { UserComponent } from './user/user.component';
import { Gunuser } from './shared/gunuser.model';

const routes: Routes = [
  {path: '', redirectTo: 'gun', pathMatch: 'full'},
  {path: 'gun', component: GunComponent},
  {path: 'guntype', component: GuntypeComponent},
  {path: 'gunautomatic', component: GunautomaticComponent},
  {path: 'user', component: UserComponent},
  {path: 'gunuser', component: Gunuser}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
