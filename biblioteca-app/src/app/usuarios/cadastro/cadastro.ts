import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UsuariosService } from '../../services/usuarios.service';
import { CepService } from '../../services/cep.service';
import { FormGroup, FormBuilder, Validators, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-cadastro',
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './cadastro.component.html',
  styleUrl: './cadastro.css',
})
export class CadastroComponent {

  cadastroForm: FormGroup;

  constructor(private fb: FormBuilder,
    private usuariosService: UsuariosService,
    private cepService: CepService) {

    this.cadastroForm = this.fb.group({
      nome: ['', Validators.required],
      cpf: ['', Validators.required],
      dataNascimento: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      username: ['', Validators.required],
      senha: ['', [Validators.required, Validators.minLength(8)]],
      cep: ['', Validators.required],
      rua: ['', Validators.required],
      bairro: ['', Validators.required],
      cidade: ['', Validators.required],
      estado: ['', Validators.required]
    });
  }

  onCepBlur() {
    const cepControl = this.cadastroForm.get('cep');
    const cep = cepControl?.value;

    if(cep && cep.length === 8 && !cepControl?.errors) {
      console.log("Chamando serviço de CEP para:", cep);

      this.cepService.buscarEndereco(cep)
        .subscribe({
          next: (dadosEndereco) => {
            if(!dadosEndereco.erro) {
              this.preencherEndereco(dadosEndereco);

            } else {
              console.warn("CEP não encontrado");

            }
          },
          error: (err) => {
            console.error('Erro na API ViaCEP:', err);

          }
        })

    }

  }

  private preencherEndereco(dados: any) {
    console.log(dados);
    this.cadastroForm.patchValue({
      rua: dados.logradouro,
      bairro: dados.bairro,
      cidade: dados.localidade,
      estado: dados.estado

    });

  }

  onSubmit() {
    if(this.cadastroForm.valid) {
      const dadosCadastro = this.cadastroForm.value;
      console.log('Formulário Válido, pronto para enviar!', dadosCadastro);

      this.usuariosService.cadastrarUsuario(dadosCadastro)
        .subscribe({
          next: (response) => {
            console.log('Cadastro efetuado com sucesso!', response);

          },
          error: (error) => {
            console.error('Erro no servidor:', error);

          }
        })
    
    } else {
      console.error('Formulário Inválido');
    }
  }
}
