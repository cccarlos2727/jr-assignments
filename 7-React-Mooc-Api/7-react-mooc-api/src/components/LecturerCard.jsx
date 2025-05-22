import React from 'react';
import { Card, CardContent, List, ListItem, ListItemText, Typography } from '@mui/material';
import './style.scss';

const LecturerCard = ({card}) => {
  return (
    <Card className='lecturer-card'>
        <CardContent>
            <Typography variant='h5' className='name'>{card.name}</Typography>
            <Typography variant="subtitle1" color="text.secondary">{card.title}</Typography>
            <Typography variant="body2" className="bio">{card.biography}</Typography>

            <Typography variant="h6" className="section-title" sx={{ marginTop: 2 }}>
                Course Taught:
            </Typography>

            <List >
                {card.coursesTaught.map((course) => (
                    <ListItem key={course.courseId}>
                        <ListItemText
                            primary={course.courseTitle}
                            secondary={`Lessons: ${course.lessons}`}
                        />
                    </ListItem>
                ))}
            </List>
            
            <Typography variant="caption" sx={{ marginTop: 1, display: 'block' }}>
              Years of Experience: {card.yearsOfExperience}
            </Typography>
        </CardContent>
    </Card>
  )
}

export default LecturerCard