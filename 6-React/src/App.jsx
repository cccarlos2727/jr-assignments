import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import CourseCard from './components/CourseCard'
import courseImg from './assets/CourseImg.webp'


function App() {

  
  const courses = [{
      id: 1,
      title: "Coding",
      price: 50,
      language: "English",
      duration: 60,
      location: "Sydney",
      img: courseImg,
      newlyAdded: true,
      difficutly: "Intermediate"
    },
    {
      id: 2,
      title: "Coding",
      price: 50,
      language: "English",
      duration: 60,
      location: "Sydney",
      img: courseImg,
      newlyAdded: null,
      difficutly: "Beginner"
    },
    {
      id: 3,
      title: "Coding",
      price: 50,
      language: "English",
      duration: 60,
      location: "Sydney",
      img: courseImg,
      newlyAdded: true,
      difficutly: "Advanced"
    }
  ]

  const [totalEnrollCount, setTotalEnrollCount] = useState(0);

  const handleTotalEnrollCount = () => {
    return setTotalEnrollCount((prev) => prev + 1);
  }


  return (
    <div>
      {courses.map((course) => (
        <CourseCard key={course.id} course={course} onEnroll={handleTotalEnrollCount}/>
      ))
      }
      <p>Total Enroll Count: {totalEnrollCount}</p>
    </div>
  )
}

export default App
