import { useEffect, useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import LecturerCard from './components/LecturerCard'
import fetchData from './utils/cardApi'

  const LECTURE_API = 'https://my-json-server.typicode.com/JustinHu8/courseCardMock/lecturers';

function App() {
  const [cards, setCards] = useState([]);
  const [error, setError] = useState('');

  useEffect(() => {
    const fetchMain = async (LECTURE_API) => {
      try {
        const data = await fetchData(LECTURE_API);
        setCards(data);
        console.log(data);
      } catch(err) {
        setError(err)
        console.error(err)
      }      
    }
    fetchMain(LECTURE_API);
  },[LECTURE_API])
  

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
