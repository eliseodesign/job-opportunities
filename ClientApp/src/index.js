import ReactDOM from 'react-dom/client'
import App from './App.js'
import {BrowserRouter} from 'react-router-dom'

const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');

ReactDOM.createRoot(document.getElementById('root')).render(
    <BrowserRouter basename={baseUrl}>
      <App />
    </BrowserRouter>,
)
