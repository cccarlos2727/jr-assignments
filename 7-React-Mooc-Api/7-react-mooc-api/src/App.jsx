import { useEffect, useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import LecturerCard from './components/LecturerCard'
import fetchData from './utils/cardApi'


function App() {
  const cardApi = 'https://my-json-server.typicode.com/JustinHu8/courseCardMock/lecturers';
  const [cards, setCards] = useState([]);
  const [error, setError] = useState('');

  useEffect(() => {
    const fetchMain = async (cardApi) => {
      try {
        const data = await fetchData(cardApi);
        setCards(data);
        console.log(data);
      } catch(err) {
        setError(err)
        console.error(err)
      }      
    }
    fetchMain(cardApi);
  },[cardApi])
  

  if(error) {
    console.log(error);
  }


  return (
    <div>
      {cards.map((card) => (
        <LecturerCard key={card.id} card={card}/>
      ))}
      
    </div>
  )
}

export default App
