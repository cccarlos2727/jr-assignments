import React, { useState } from 'react'

const CourseCard = ({ course, onEnroll }) => {
  const { key, title, price, language, duration, location, img, newlyAdded, difficutly, isCompleted } = course;

  const [isReviewed, setIsReviewed] = useState(false);
  const [isSubmitted, setIsSubmitted] = useState(false);
  const [enrollCount, setEnrollCount] = useState(0);  

  const handleReviewed = () => {
    return setIsReviewed(!isReviewed);
  }

  const handleIsSubmitted = () => {
    return setIsSubmitted(true);
  }

  const handleEnrollCount = () => {
    setEnrollCount((prev) => prev + 1);
    onEnroll(course.title);
  }

  return (
    <div className='card-container'>
        <div className="cardleft">
            <h3>{`Course Name: ${title}`}</h3>
            <p>{`Price: ${price}`}</p>
            <p>{`Language: ${language}`}</p>
            <p>{`Duration: ${duration} hours`}</p>
            <p>{`Location: ${location}`}</p>
            <p className='difficlty'>{`Difficulty: ${difficutly}`}</p>
            <p>{`Enrolled ${enrollCount}`}</p>
            {isCompleted === "no"?
              <button onClick={handleEnrollCount}>Start Course</button>:
              <button >Revisit Course</button>
            }            

            {newlyAdded? 
            <span className='badge'>Newly Added!</span>:
            null
            }
            {isReviewed? (
            isSubmitted? (
              <button>Review Submitted</button>
            ): (
              <>
              <input type='text'/>
              <button onClick={handleIsSubmitted}>Submit</button>
              </>
            )
          ): 
              <button onClick={handleReviewed}>Leave a Review~</button>
            }
            
            

        </div>

        <div className='cardright'>
            {img? 
            <img src={img} alt='Course Img'/>
            : null
            }
        </div>
      
    </div>
  );
};

export default CourseCard