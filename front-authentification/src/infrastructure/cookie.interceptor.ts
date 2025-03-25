import { HttpInterceptor, HttpInterceptorFn } from "@angular/common/http";
export const cookieInterceptor: HttpInterceptorFn = (request,next)=> {
  const newRequest = request.clone({
      withCredentials:true,
  })
  return next(newRequest);
}
/*if (request.url.startWith("https://localhost:50000/')){
  const new request : HttpRequest <unconk> = request .clone({
    withCredentials:true,
  })

  return next(newRequest);
}
return next(request);
}*/
