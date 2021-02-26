package com.example.service;

import com.example.demo.Student;
import com.example.repository.StudentRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import javax.transaction.Transactional;
import java.util.List;

@Service
@Transactional
public class StudentService {

    @Autowired
    private StudentRepository repository;

    public List<Student> listAll() {
        return repository.findAll();
    }

    public void save(Student student) {
        repository.save(student);
    }

    public Student get(int id) {
        return repository.findById(id).get();
    }

    public void delete(int id) {
        repository.deleteById(id);
    }

    //From the stored procedure
    public List<Student> getAllStudents() {
        return repository.getAllStudents();
    }

    //From the stored procedure
    public Student getStudentById(int id) {
        return repository.getStudentById(id);
    }

    //From the stored procedure
    public void insertStudentSP(Student student) {
        repository.insertStudentSP(student.getName(),
                student.getEmail(), student.getPassword());
    }

    //From the stored procedure
    public void updateStudentSP(Student student) {
        repository.updateStudentSP(student.getStudentId(),student.getName(),
                student.getEmail(), student.getPassword());
    }

    //From the stored procedure
    public void deleteStudentSP(int id) {
        repository.deleteStudentSP(id);
    }

}