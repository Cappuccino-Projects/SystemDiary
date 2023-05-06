import {
  useCallback,
  useState
} from 'react'

export function useApi() {
  const HOST = `http://${process.env.REACT_APP_API_ADDRESS}:${process.env.REACT_APP_API_PORT}/`;
  const [error, setError] = useState();

  /**
   *  Функция осуществляет отправку данных на сервер 
   */
  const makeRequest = useCallback(async (data) => {

    try {

      const response = await fetch(HOST + data.url, {
        "method": data.method,
        "body": data.body,
        "headers": data.headers,
      });

      const response_data = await response.json();

      if (!response.ok) {
        throw new Error(response_data.message || 'Что-то пошло не по плану');
      }

      return response_data;

    } catch(e) {
      setError(e);
    }

  }, []);

  return { makeRequest, error }

}