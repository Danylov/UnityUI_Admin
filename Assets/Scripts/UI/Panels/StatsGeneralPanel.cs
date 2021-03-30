using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatsGeneralPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text successCompletedTrainingsCounter;
    [SerializeField] private TMP_Text runningTrainingsCounter;
    [SerializeField] private TMP_Text registeredStudentsCounter;

    public void StatsGeneralVisualization()
    {
        var sessionsDB = new SessionsDB();
        successCompletedTrainingsCounter.text = sessionsDB.getNumberCompletedSessions().ToString();
        runningTrainingsCounter.text = sessionsDB.getNumberRunningSessions().ToString();
        sessionsDB.close();
        var studentsDB = new StudentsDB();
        registeredStudentsCounter.text = studentsDB.getNumberRegisteredStudents().ToString();
        studentsDB.close();
    }
}
