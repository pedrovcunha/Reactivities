import ReactDOM from 'react-dom';
import './app/layout/styles.css';
import 'react-calendar/dist/Calendar.css';
import 'react-toastify/dist/ReactToastify.min.css';
import App from './app/layout/App';
import reportWebVitals from './reportWebVitals';
import { store, StoreContext } from './app/stores/store';
import { BrowserRouter, Router } from 'react-router-dom';
import { createBrowserHistory } from 'history';


// React Strict mode enforce any code that is deprated or outdated into React17 version.
// This will work with all React code, but may interfer our third party with one o more outdated components. So let's remove for now.
// ReactDOM.render(
//   <React.StrictMode>
//     <App />
//   </React.StrictMode>
//   ,
//   document.getElementById('root')
// );

export const history = createBrowserHistory();

ReactDOM.render(
  <StoreContext.Provider value={store}>
    <Router history={history}>
      <App />
    </Router>
  </StoreContext.Provider>,
  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
