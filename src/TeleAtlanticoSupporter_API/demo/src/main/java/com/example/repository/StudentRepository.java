package com.example.repository;

import com.example.demo.Student;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.jpa.repository.query.Procedure;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;
import java.util.List;

@Repository
public interface StudentRepository extends JpaRepository<Student, Integer>{

    @Query(value = "SelectStudent", nativeQuery = true)
    List<Student> getAllStudents();

    @Query(value = "{ call SelectStudentById(:Student_id)}", nativeQuery = true)
    Student getStudentById(@Param("Student_id") Integer studentId);

    @Procedure(value = "Student.insertStudentSP")
    void insertStudentSP(@Param("name") String name,
                         @Param("email") String email,
                         @Param("password") String password);

    @Procedure(value = "Student.updateStudentSP")
    void updateStudentSP(@Param("Student_Id") Integer studentId,
                         @Param("name") String name,
                         @Param("email") String email,
                         @Param("password") String password);

    @Procedure(value = "Student.deleteStudentSP")
    void deleteStudentSP(@Param("Student_Id") Integer studentId);

}
