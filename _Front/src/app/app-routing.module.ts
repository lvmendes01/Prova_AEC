import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


import { AuthGuard } from './_helpers';
import { CadastroPerfilComponent } from './_components/perfil';
import { ListaPerfilComponent } from './_components/perfil/lista-perfil/lista-perfil.component';
import { HomeComponent } from './_components/home';
import { UsuarioComponent } from './_components/usuario/usuario.component';
import { ListaUsuarioComponent } from './_components/usuario/lista-usuario/lista-usuario.component';

const accountModule = () => import('./_components/account/account.module').then(x => x.AccountModule);

const routes: Routes = [
    { path: '', component: HomeComponent, canActivate: [AuthGuard] },
    { path: 'perfilcadastro',  component: CadastroPerfilComponent, canActivate: [AuthGuard] },
    { path: 'perfil',  component: ListaPerfilComponent, canActivate: [AuthGuard] },
    { path: 'usuariocadastro',  component: UsuarioComponent, canActivate: [AuthGuard] },
    { path: 'usuario',  component: ListaUsuarioComponent, canActivate: [AuthGuard] },
    { path: 'account', loadChildren: accountModule },
    
    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }