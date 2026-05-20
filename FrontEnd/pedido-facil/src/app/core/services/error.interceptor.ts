import { HttpErrorResponse, HttpInterceptorFn } from '@angular/common/http';
import { catchError, throwError } from 'rxjs';

export const errorInterceptor: HttpInterceptorFn = (req, next) => {
  return next(req).pipe(
    catchError((error: HttpErrorResponse) => {
      const message = error.error?.Message || error.error?.message || error.message || 'Erro inesperado.';
      return throwError(() => new Error(message));
    })
  );
};
