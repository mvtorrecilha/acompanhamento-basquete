export interface ApiResponse<T> {
  data: T;
  successo: boolean;
  mensagem: string;
  erros: string[];
}
