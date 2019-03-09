CalculatorService.Server

Aplicación desarrollada con el framework asp.neten el ambiente Visual Studio 2017

La solucion contiene un servicio Rest con diferentes metodos para efectuar calculos matematicos. Si el cliente dentro del encabezado de la peticion envia la llave "X-Evi-Tracking-Id" persiste los datos de las operaciones efectuadas por dicho usuario y luego pueden ser consultadas mediante la peticion  query que tiene como parametro el id del cliente.

Ademas se almacenan registros en el servidor dentro de la carpeta Log, uno de ellos es el log de la aplicacion para poder rastrear lo errores que se presentan al efectuar las diferentes peticiones y los otros archivos pertenecen a las operaciones que se persisen y tiene como nombre el id del cliente.

Las peticiones disponibles son:

calculator/add : Recibe json con llave Addends que como valor contiene el array con los numeros que desee sean sumados y como respuesta se obtiene json con el resultado de la suma de los numeros enviados.

calculator/sub : Recibe json con llaves Minuend y Subtrahend que como valores contienen los numeros pertenecientes a las partes de la resta minuendo y sustraendo, y como respuesta se obtiene json con el resultado de la resta entre los dos numeros enviados.

calculator/mul : Recibe json con llave Factors que como valor contiene el array con los numeros que desee sean multiplicados y como respuesta se obtiene json con el resultado de la multiplicacion de los numeros enviados.

calculator/div : Recibe json con llaves Dividend y Divisor que como valores los contienen numeros pertenecientes a las partes de la division dividendo y divisor, y como respuesta se obtiene json con el resultado de la parte entera de la division y su residuo.

sqrt : Recibe json con llave Number y como valor el numero al cual se le desea obtener la raiz cuadrada y como respuesta obtiene json con el resultado de la operacion.

journal/quer : Recibe json con llave Id y como valor la identificacion del Cliente y como respuesta obtiene json con las operaciones con las peticiones almacenadas cuando en el encabezado de la peticion agragaban la llave X-Evi-Tracking-Id con el valor de la identificacion del cliente.
