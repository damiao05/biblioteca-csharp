import { Routes } from '@angular/router';
import { CadastroComponent as UsuarioCadastroComponent } from './usuarios/cadastro/cadastro';

export const routes: Routes = [
    {
        path: 'usuarios/cadastro',
        component: UsuarioCadastroComponent
    }
];
